﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecoveryFlasher.Localization.MessageBox {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Content {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Content() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RecoveryFlasher.Localization.MessageBox.Content", typeof(Content).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Драйвера подходят только для телеонов Xiaomi (Mi, Redmi, Poco)!
        ///
        ///Данные &apos;драйвера&apos;, а точнее их установщик - это программа взятая из официальной программы Xiaomi &apos;Mi Unlock&apos;. Её можно найти в папке с &apos;Mi Unlock&apos; под названием &apos;MiUsbDriver.exe&apos;.
        ///
        ///Для их установки, нужно нажать в данной программе кнопку &apos;Установить&apos;, и подключить телефон в режиме &apos;fastboot&apos;. Если телефон уже был подключён - переподключить..
        /// </summary>
        internal static string AboutDrivers {
            get {
                return ResourceManager.GetString("AboutDrivers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Поздравляю!
        ///У вас кастомное рекавери :)
        ///
        ///Если телефон не перезагрузился в рекавери, попробуйте войти в него сами, на Xiaomi устройствах это делаеться зажатием при вкл. кнопки вкл. и громкость +.
        ///Если всё ещё нет рекавери то возможно ваш телефон нельзя прошить таким способом.
        ///
        ///Хорошего дня!.
        /// </summary>
        internal static string Congratulations {
            get {
                return ResourceManager.GetString("Congratulations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Устройство не подключено.
        ///Попробовать снова?
        ///
        ///Если устройства дальше нет, проверьте драйвера..
        /// </summary>
        internal static string DeviceNotFound {
            get {
                return ResourceManager.GetString("DeviceNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Драйвера установлены!.
        /// </summary>
        internal static string DriverInstallSuccessful {
            get {
                return ResourceManager.GetString("DriverInstallSuccessful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Рекавери для своего телефона можно найти в разделе вашего телефона на таких форумах как &apos;4PDA.ru&apos; и &apos;xda-developers.com&apos;.
        ///Чаще всего рекавери находяться в разделе &apos;Неофициальные прошивки&apos;..
        /// </summary>
        internal static string FindRecovery {
            get {
                return ResourceManager.GetString("FindRecovery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Произошла ошибка :(
        ///
        ///Детали ошибки: .
        /// </summary>
        internal static string FlashError {
            get {
                return ResourceManager.GetString("FlashError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Рекавери не выбрано..
        /// </summary>
        internal static string RecoveryNotSelect {
            get {
                return ResourceManager.GetString("RecoveryNotSelect", resourceCulture);
            }
        }
    }
}
