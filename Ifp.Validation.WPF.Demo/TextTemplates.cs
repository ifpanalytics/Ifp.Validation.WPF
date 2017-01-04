using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifp.Validation.WPF.Demo
{
    static class TextTemplates
    {
        public static readonly string MessageInfoBithdate = "You did not enter a birth date. You will not be able to use some of our services. You can add this information later.";
        public static readonly string MessageWarningPassword = "The password you entered is valid but weak. Do you want to use it anyway?";
        public static readonly string MessageErrorEmail = "The mail address you entered is invalid.";
        public static readonly string MessageErrorSurname = "You must enter a surname.";

        public static readonly string[] BlindTexts = new string[] {
        @"Lorem ipsum amet eu bibendum vel suspendisse, primis dapibus neque euismod scelerisque, nunc ultricies torquent varius nunc leo velit sollicitudin neque at elementum potenti. At lacinia ac amet nisi facilisis turpis quisque, mi massa sodales imperdiet suscipit diam sodales vel, duis fermentum facilisis interdum per ligula. Orci ut venenatis tempus urna pulvinar semper, ut curae cubilia elit elementum auctor, vitae hendrerit vulputate condimentum egestas.",
        @"Lorem mi aliquet venenatis torquent class eu suspendisse, tincidunt velit posuere risus lorem accumsan, litora euismod senectus nisl libero aptent. Bibendum pharetra vulputate eleifend curabitur lorem, placerat scelerisque semper erat proin, arcu sit aliquam orci. Platea auctor scelerisque varius nostra aliquet facilisis eros nostra amet ipsum at enim ullamcorper.",
        @"Magna euismod sagittis ipsum facilisis nunc malesuada cras, gravida phasellus massa metus vitae turpis platea egestas, urna aliquet aptent tellus ad vitae.",
        @"Pharetra senectus orci justo vestibulum enim donec taciti litora, tellus blandit adipiscing eros sed praesent non congue, dolor lacinia quam per habitant maecenas malesuada.",
        @"Quam gravida varius facilisis elementum vulputate consectetur lectus tempor ullamcorper aliquam velit semper, dolor aliquet nisl nam est aliquam consectetur cursus faucibus per praesent.",
        @"Integer pulvinar libero arcu in curae in nulla venenatis ullamcorper praesent sed.",
        @"Leo tortor congue quis nulla cras litora at, quisque mattis mi aliquam pretium faucibus nisi, aenean cras odio auctor pharetra odio.",
        @"Tincidunt donec sit eros aliquet at sem scelerisque mauris a, quisque sapien bibendum viverra eros mattis vulputate congue, hac fermentum aliquam maecenas eget class purus mattis." };
    }
}
