﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.17929
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Orchestra.Modules.Julia.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Orchestra.Modules.Julia.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Ищет локализованную строку, похожую на &lt;?xml version=&quot;1.0&quot;?&gt;
        ///&lt;SyntaxDefinition xmlns=&quot;http://icsharpcode.net/sharpdevelop/syntaxdefinition/2008&quot;&gt;
        ///  &lt;Color name=&quot;Comment&quot; foreground=&quot;Green&quot; exampleText=&quot;# comment&quot; /&gt;
        ///  &lt;Color name=&quot;Keywords&quot; fontWeight=&quot;bold&quot; foreground=&quot;Blue&quot; exampleText=&quot; &quot;/&gt;
        ///  &lt;Color name=&quot;ValueTypes&quot; fontWeight=&quot;bold&quot; foreground=&quot;Red&quot; exampleText=&quot; &quot; /&gt;
        ///  &lt;Color name=&quot;String&quot; foreground=&quot;Blue&quot; exampleText=&quot;string text = &amp;quot;Hello, World!&amp;quot;&quot;/&gt;
        ///  &lt;Color name=&quot;Escape&quot; fontWeight=&quot;bold&quot; foreground=&quot;Red&quot; exampleText=&quot;s [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string JuliaLang {
            get {
                return ResourceManager.GetString("JuliaLang", resourceCulture);
            }
        }
    }
}
