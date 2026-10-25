$cecil = Import-Csv "translations\dialogues\prologue_cecil_extracted.csv"

# Let's filter specifically for Prologue methods:
$prologueStrict = $cecil | Where-Object {
    $_.Class -like "*Prologue*" -or
    $_.Method -like "*Prologue*" -or
    $_.Class -like "*IntroCarriage*" -or
    $_.Class -like "*UnterwaldPaintingScene*" -or
    $_.Class -like "*UnterwaldSpeech*" -or
    $_.Class -like "*HermanDisappears*" -or
    ($_.Class -like "*RoomInterrogation*" -and $_.Class -notlike "*ActTwo*" -and $_.Class -notlike "*Chapter*") -or
    ($_.Class -like "*RoomArthurQuarters*" -and $_.Class -notlike "*Act*")
}

Write-Host "Strict Prologue dialogue lines: $($prologueStrict.Count)"
$uniqueTexts = $prologueStrict | Select-Object -Property Character, Text, Class -Unique
Write-Host "Unique dialogue entries: $($uniqueTexts.Count)"

$uniqueTexts | Export-Csv "translations\dialogues\prologue_lines_to_translate.csv" -NoTypeInformation -Encoding UTF8
Write-Host "Exported to translations\dialogues\prologue_lines_to_translate.csv"
