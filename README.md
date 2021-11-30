# Alta-2
<img src="https://github.com/c-hristian-t/Alta-2/blob/main/images/Banner.png?raw=true" alt="banner">
<b>A general purpose discord.NET bot to make administration easier and servers more engaging! From virtual currency and shops to advanced moderation tools, Alta is built from the core to deliver.</b>
While this project is still in it's Alpha phase and not release ready, you are completely free to try alta for yourself! you can report any bugs found <a href="https://.github.com/c-hristian-t/Alta-2/issues>">here!</a> please make sure to read the setup information below as it offers helpful information for setting up Alta correctly. 

## Setup

<img align="right" width=175 src="https://github.com/c-hristian-t/Alta-2/blob/main/images/Settings.png?raw=true" />

things to keep in mind:
  - a cdn or any similar file hosting server is required as any images are loaded from the web as apposed to locally
  - the project needs to be built/compiled and deployed manually at this time, once Alta is release ready, a release on github will be made.
  - While you may host Alta yourself, the released version of the project will be hosted by myself. <b>if you are just looking to add this bot to your server, you may do so <a href="https://discord.com/api/oauth2/authorize?client_id=913637463786938368&permissions=8&scope=bot">with this link.</a></b>
  - As of current the Alta client does not connect to a remote database, while this may change in the future to allow different clients to use the same configuration for individual users, our database will not be accesible by your client. In the future you may need to set up your own database.
  - Slash commands are currently unavailable but will be added as soon as possible. Alta makes use of a message prefix for now.

## CDN setup
When uploading image files to your CDN or file server, keep in mind that while the address of your cdn is easily configurable upon startup of the client, file naming is strict. below you can see all of the different file names Alta uses. This repository comes with images already named and ready to move to your server,

File name|commands|summary
---------|-------|-------
a_profile|All|Alta's profile photo
a_settings|General and system commands|used when handling anything to do with Alta's general configuration or it's status
a_server|Ping|Used with commands that handle connection status
a_error|N/A|Used whenever Alta throws an error
a_user|user config|Used when a user is configuring their own settings.

note that the above table is incomplete.

## Token and CDN configuration
as mentioned above, Alta will ask for your cdn address and your login token upon first startup or if these items are missing. as of current there is no way to switch your cdn or token without opening the root folder of the program and seaching for the files containing these strings. further into the project this will be possible.

## Contributing to Alta
Some of you have too much free time on your hands and that's great! If you wish to contribute to this project, submit your changes as Pull Requests to the <a href="github.com/c-hristian-t/Alta-2/tree/bleeding-edge">Bleeding Edge</a> branch.

## Support
The following resources are available if you ever find yourself needing help!

<a href="https://discord.gg/jQqpyjASaJ">Metro Discord</a>

<a href="https://madebymetro.com">Metro Website (under construction)</a>

<a href="https://github.com/c-hristian-t/Alta-2/issues">Alta Issues</a>

## Credits
me

## License
Alta is published under the GPL license as it's core values are to be open and free to all. The GPL comes with both rights and obligations. Alta must remain open and source code must be provided upon the request of an end user. The easiest way to comply with this is to fork this project on Github and modify the code from there, and then you may direct your users to the modified fork. I cannot prevent you from using this code in closed source products and project, but I would prefer that you choose another option or create your own if this is what you wish to do.
