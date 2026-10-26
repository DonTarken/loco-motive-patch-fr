using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program {
    static void Main() {
        string dir = @"D:\Games\Loco Motive\Loco Motive_Data";
        var itemNames = new HashSet<string>();
        
        // Search in resources.assets and *.assets
        foreach (var file in Directory.GetFiles(dir, "*.assets")) {
            byte[] bytes = File.ReadAllBytes(file);
            string content = Encoding.UTF8.GetString(bytes);
            
            // Look for patterns like m_description or m_guiText or Inventory
            // In PowerQuest, Inventory items are ScriptableObjects with fields: m_description, m_guiText, etc.
        }
    }
}
