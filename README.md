# Global Toggle Mod Generator

(WIP) Generates the metadata for "global toggle mods" for Penumbra, allowing every single gear item to be replaced with the same modded item or set.

## Usage
In this initial prototype, the parameters are hard-coded.  A future version will have either a config file or command line parameters.

* (Temporary step) Edit the source code as desired
* Run the program to create the file `mod_out.txt`
* Create a multi option group for your mod in Penumbra
* Open your mod in Explorer
* There should be two files for your option group, named something like `group_001_toggles.json` and `group_001_toggles.json.bak`
* Replace your `.json` file (not the `.bak` file) with `mod_out.txt`.
  * Equivalently, replace the contents of `group_001_toggles.json` with the contents of `mod_out.txt`, but this isn't recommended as `mod_out.txt` is large  

### Modded file paths
Change `HEAD_PATH`, `BODY_PATH` etc to the relative file path of the desired replacement model file

### EQP bitfield values
Flags to hide or show body parts, enable physics, etc.  The default values show all body parts.

### EQDP bitfield values
Flags to enable race/gender-specific model and material variants.  Currently this is hardcoded to force enable
unique models for Midlander F, and disable unique models and materials for all other races except Lalafell.
