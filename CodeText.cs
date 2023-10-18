namespace Dart_Class_Generator
{
    class CodeText
    {
        public static string HeaderText(string className, string lowerClassName)
        {
            return $@"import 'dart:convert';

{className}? {lowerClassName}FromJson(String str) => {className}.fromJson(json.decode(str));

String {lowerClassName}ToJson({className}? data) => json.encode(data!.toJson());

List<{className}> {lowerClassName}ListFromJson(String str) => List<{className}>.from(json.decode(str).map((x) => {className}.fromJson(x)));

String {lowerClassName}ListToJson(List<{className}?> data) => json.encode(List<dynamic>.from(data.map((x) => x!.toJson())));

class {className} {'{'}
  {className}({'{'}";
        }
        public static string ToStringText(string LeftCurlyBraces, string className, string Apostrophe)
        {
            return "\n\n" + $@"  @override
  String toString() {LeftCurlyBraces}
    return {Apostrophe}{className} {LeftCurlyBraces}";
        }
        public static string FactoryText(string RightCurlyBraces, string className, string Apostrophe)
        {
            return $@"{RightCurlyBraces + Apostrophe};
  {RightCurlyBraces}

  factory {className}.fromJson(Map<String, dynamic> json) => {className}(";
        }
        public static string MapText()
        {
            return "\n" + @"      );

  Map<String, dynamic> toJson() => {";
        }
        public static string EndText()
        {
            return "\n" + @"      };
}";
        }
    }
}