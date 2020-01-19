# Reminders_V1 #
#### A Windows form .NET application written using C#! ####
This application was written using Visual Studio and the .NET library in C#, with programmatic SQLite for data saving.

### Features ###
* Reminds user upon boot/login (optional)
* Decide for how many days to remind user of a specific reminder
* Custom date format, font size, and remind frequency
* Automatically saves column widths as user drags/adjusts them

### Prerequisites/Dependencies ###
* .NET 4.6.1 framework -- use setup.exe to both download it and install Reminders

## v1.1.15 - January 19, 2020 ##
+ Now creates database file when necessary
+ Font size stays the same when sort by any column
+ Fixed the following button states issues:
  + When the Edit button is first clicked, Confirm Edits button is enabled, but not the second time
  + When date or days is changed, the Confirm Edits button is not enabled
  + When any are empty, Confirm Edits button is still enabled
  + Confirm Edits button is enabled whether or not description coincides with the original
  + When editing, the Add button switches states sometimes
