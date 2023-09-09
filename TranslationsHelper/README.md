# Translations Helper

Mod for helping modders that maintain huge amounts of prefabs and want to provide translations files for those.
This mod will help you pre-generate all translations files that you need to provide with your .dll in English language.
Any prefabs that have a missing `m_name` or `m_description` will be printed with a String ("[token name]") that shows
missing translation.

At Krumpac's Reforge mod pack we are using this mod to keep track of the 1600 added prefabs and all their translations,
which would be a lot of work without automation.

## Features

Load this together with your other .dlls and in-game use `F5` (using `-console`) and type `print_translations_to_file`,
this will generate all available (non-vanilla) prefabs into 1 file per BepInExPlugin that adds this prefab.

### Valheim Types supported

Output available for in-game Valheim types:

* ItemDrop
* Piece
* Character
* Smelter
* Fermenter
* CookingStation
* Incinerator
* OfferingBowl
* SapCollector
* Beehive
* HoverText

For the simpler types the mod will use the `m_name` and `m_description` fields located inside those types, the
pre-generated translation String is taken from any available text that comes with the prefab or the mod that introduced
it. More complex types that have additional texts or switches will also have those printed.

### Filter output

You can also specify 1 argument to the console command to apply prefix filtering for the outputs:

```
print_translations_to_file my_mod_prefix_
```

This will then just output prefabs that have their internal name starting with "my_mod_prefix_" and will also just
generate files for .dlls where this prefix is available.

## Examples

Example file output (taken from mod [Rune Magic](https://valheim.thunderstore.io/package/hyleanlegend/Rune_Magic/)):

File name:

```yaml
BepInEx/config/TranslationsPrinterOutput/RuneMagic.English.yaml
```

Example content (excerpt):

```yaml
RuneFocus: "Rune Focus"
RuneFocus_Description: "Use this on Runestones you discover to absorb their power and shape it to your own ends."
runemagic_BlastingRune: "Rune of Blasting"
runemagic_BlastingRune_Description: "Who needs a pickaxe when you can blast stone apart with magic?  Though, do remember to stand clear..."
runemagic_CalmWatersRune: "Rune of Calm Waters"
runemagic_CalmWatersRune_Description: "A smooth sea doesn't make a skilled sailor, but it does help keep your ship in one piece."
runemagic_CanopyRune: "Canopy Rune"
runemagic_CanopyRune_Description: "It's no warm inn with a roaring fire, but it'll keep the damp off."
runemagic_DryLandRune: "Rune of Dry Land"
runemagic_DryLandRune_Description: "Rising sea levels are no longer a concern."
```

# Miscellaneous

<details>
  <summary>Attributions</summary>

* https://valheim.thunderstore.io/package/ValheimModding/Jotunn/
* icon -> https://www.flaticon.com/free-icons/translate

</details>

<details>
  <summary>Contact</summary>

* https://github.com/FelixReuthlinger/TranslationsHelper
* Discord: fluuxxx (you can find me around some of the Valheim modding discords, too)

</details>
