using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading.Tasks;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Infrastructure
{
    public class LocalizationManager
    {
        private static LocalizationManager? _instance;
        private static readonly object _lock = new object();
        
        private ResourceManager? _resourceManager;
        private CultureInfo _currentCulture;
        private readonly IServiceProvider _serviceProvider;
        private ITranslationService? _translationService;

        public event EventHandler<LanguageChangedEventArgs>? LanguageChanged;

        private LocalizationManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _currentCulture = new CultureInfo("en");
            InitializeResourceManager();
        }

        public static LocalizationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("LocalizationManager not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LocalizationManager(serviceProvider);
                    }
                }
            }
        }

        private void InitializeResourceManager()
        {
            try
            {
                _resourceManager = new ResourceManager("UI.Resources.Strings", typeof(LocalizationManager).Assembly);
            }
            catch
            {
                // Fallback to empty resource manager if resources not found
                _resourceManager = new ResourceManager("System.String", typeof(string).Assembly);
            }
        }

        public void SetLanguage(string languageCode)
        {
            var newCulture = new CultureInfo(languageCode);
            if (_currentCulture.Name != newCulture.Name)
            {
                _currentCulture = newCulture;
                CultureInfo.CurrentUICulture = _currentCulture;
                
                // Initialize translation service if not already done
                if (_translationService == null)
                {
                    _translationService = _serviceProvider.GetService<ITranslationService>();
                }

                LanguageChanged?.Invoke(this, new LanguageChangedEventArgs(languageCode));
            }
        }

        public string GetString(string key)
        {
            try
            {
                var value = _resourceManager?.GetString(key, _currentCulture);
                return value ?? key; // Return key if translation not found
            }
            catch
            {
                return key;
            }
        }

        public async Task<string> GetDbTranslationAsync(string entityName, int entityId, string fieldName)
        {
            try
            {
                if (_translationService == null)
                {
                    _translationService = _serviceProvider.GetService<ITranslationService>();
                }

                if (_translationService != null)
                {
                    var translations = await _translationService.GetByEntityAsync(entityName, entityId);
                    var translation = translations?.FirstOrDefault(t => 
                        t.FieldName == fieldName && 
                        t.LanguageCode == _currentCulture.TwoLetterISOLanguageName);

                    return translation?.TranslatedText ?? GetDefaultText(entityName, entityId, fieldName);
                }
            }
            catch
            {
                // Fallback to default text
            }

            return GetDefaultText(entityName, entityId, fieldName);
        }

        private string GetDefaultText(string entityName, int entityId, string fieldName)
        {
            // This would typically fetch the original text from the database
            // For now, return a placeholder
            return $"[{entityName}.{entityId}.{fieldName}]";
        }

        public string GetCurrentLanguage()
        {
            return _currentCulture.TwoLetterISOLanguageName;
        }

        public CultureInfo GetCurrentCulture()
        {
            return _currentCulture;
        }

        public bool IsRightToLeft()
        {
            return _currentCulture.TextInfo.IsRightToLeft;
        }
    }

    public class LanguageChangedEventArgs : EventArgs
    {
        public string LanguageCode { get; }

        public LanguageChangedEventArgs(string languageCode)
        {
            LanguageCode = languageCode;
        }
    }
}
