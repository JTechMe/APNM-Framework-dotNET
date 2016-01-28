# APNM How-To
## The Manifest
### Creating the Manifest
The manifest file is the fisrt object that the JumpGo browser will call to open the app. To begin, create your "project.apnm" file in your app project directory. This file is your manifest file. A sample manifest file can be found in this project.
The first line of your manifest file should contain the APNM version; ```` APNM.project.manifestVersion{1.0.0} ```` The next 3 lines contain comments only;
````
~(c)JTechMe 2016
~The APNM framework is licenced under the General-Open-Control-License-v1.0
~Do not delete the first 4 lines in this document.
````
After this, line 5 is where you will place your app name; ```` APNM-Framework ```` line 6 is where you place your app's package namespace; ```` com.jtechme.apnmframework ```` and the 4th line is for your app's version identifier; ```` 1.0.0 ````
The next 2 lines are used as comments;
````
~This is the official framework for developing web apps and extentions for the JumpGo Desktop browser.
~Permissions always start on line 10 and end on line 21
````
Line 10 is the start of the permissions; ```` !permissions! ````
The different permissions you can grant your application are as follows;
````
+FRAMEWORK_USE+
+INTERNET_ACCESS+
+PROJECT_DIR+
+LOCAL_FILES+
+JG_SETTINGS+
+APNM_SETTINGS+
````
FAMEWORK_USE is a required permission by the APNM-Framework. INTERNET_ACCESS and PROJECT_DIR are recommended permissions for apps that utilize internet access or cache files. LOCAL_FILES is only to be used if your app can access files on the local machine outside your project's folder. JG_SETTINGS is a permission that the user must grant manually because it grants the ability to change the settings of the JumpGo browser. APNM_SETTINGS is not a permission for use by 3rd party apps because it grants the ability to alter the APNM-Framework settings and files.
You cannot end the ```` !permissions! ```` until the 21st line. Now the 3 lines after that are comments again;
````
~The icon file is always referenced on line 26
~The default icon name is "icon.ico" but can be changed to any other *.ico file.
~The icon file is always a *.ico file and cannot be changed.
````
After this, the icon file is referenced;
````
<iconfile>{
icon.ico
}
````
The next line is again for use as a comment; ```` ~Now call your "index.html" file ```` And as the comments suggests, you call the index.html file next;
````
<index>{
index.html
}
````
That is how you format the project.apnm manifest file.
