Windows front end GUI for use with Devine (created by the devine team available at GitHub here https://github.com/devine-dl/devine

This application uses all the underlying Python code created above and will initiate a new Command Prompt window each time your perform an action within Devine GUI.

Pre-requisites

Devine v3.3.3 and all it's requirements as per https://github.com/devine-dl/devine

Windows .NET 6.0 Desktop Runtime

Installation: the DevineGUI is a portable executable and does not require to be installed. You can place the Devine GUI folder in any location on your machine, there is no specific folder location requirement. When running DevineGUI for the first tme please set your Devine folder location ie: that is the Devine folder from https://github.com/stabbedbybrick/Devine (this is a Mandatory step) You may also choose to set your Downloads folder location in the Options (this is an optional step, however it will update the folderpath in your devine.yaml file if you use this option)

Note: there are no services included with this release. Services must be configured separately in your Devine/services folder before using this application.

DevineGUI v1.0.0 initial release

Operation

Search and Info
1. Search: Choose the streaming service in Option 1 and the Search button in Option 2. Type what your looking for in Option 4 and click Go or hit Enter. Search capability must be configured in the Service in order to function.
2. List Available Titles: Get the series URL from your search or direct from the service website Type/paste into Option 4 and click Go or hit Enter
3. Print Title Info: Type the episode number in Option 3 and get the series URL from your search or direct from the service website Type/paste into Option 4 and click Go or hit Enter to see info for that episode
4. Help: Choose to display devine dl help info
5. Version: Choose to display the devine version number
6. Clear Cache: Choose to clear devine Cache

Download
1. Download options available are Episode(s), Subtitles only, Video Only, Audio only and Audio & Video only. Choose the streaming service in Option 1, download choice at Option 2, the Episode/Series/Range and Option 3 and series URL/ID at Option 4

Optional Items
These items are all configurable as options on each command.
1. Video resolution
2. Video codec
3. Video bitrate
4. Audio codec
5. Proxy (by default devine will choose a proxy if required based on geo-location. This option gives you the choice of 'no proxy" or another country)
6. Threads
7. Tag
8. Subtitle format
9. Subtitle language
10. Decryption
11. Additional commands: No folder, No source, Skip download, Slow
    
![Screenshot 2024-05-29 115132](https://github.com/billybanana80/DevineGUI/assets/149659663/7c54074c-8125-4cd9-97e3-c23c89e7900d)

Queue
1. you may choose to add each item to a queue, rather than click Go for each individual search/download. The command will be added to a queue.bat file in your devine folder location. Click Process to run all the items in the queue at once

Options
1. Devine folder location: this is a mandatory step and is required for this appkication to function.
2. Downloads folder location in the Options (this is an optional step, however it will update the folderpath in your devine.yaml file if you use this option)
3. Set Service profile: allows you to create your username/password credentials for a service and it will be saved to your devine.yaml file
4. Downloader: set your required downloader, choice of aria2c, curl_impersonate or requests (note: requests is the default)
5. Empty Temp folder: clears all folders and files in your devine temp folder
6. Env Info: displays the devine config info
7. Open Config File: opens the devine.yaml file and is in an editable state
8. Upgrade Devine version: will check and upgrade the devine python package where necessary
9. Test CDM: use to test the validity of your CDM

![Screenshot 2024-05-30 082001](https://github.com/billybanana80/DevineGUI/assets/149659663/5e81316d-2aab-41c3-ab67-60efc70d61c2)

Proxy
1. Hola List Countries: displays the list of countries available in the hola-proxy function
2. Hola Version: displays the current Hola version

Favorites
1. Favorites button will display list of your series that you follow and can save as a Favorite. Highlight a row and click Copy to send the series URL to the main window in Option 4

![Screenshot 2024-05-30 081945](https://github.com/billybanana80/DevineGUI/assets/149659663/0afbe27b-5b46-4b14-a133-c88c7dcffe58)

Sites
1. Choose a service from the Sites list to open their website

Disclaimer

This project is made as a part time hobby. There will be some bugs along the way. It is designed for educational purposes only and does not condone piracy.
