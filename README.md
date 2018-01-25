[logo]: https://raw.githubusercontent.com/Geeksltd/Zebble.Sharing/master/Shared/NuGet/Icon.png "Zebble.Sharing"


## Zebble.Sharing

![logo]

A Zebble plugin for sharing in Zebble application.


[![NuGet](https://img.shields.io/nuget/v/Zebble.Sharing.svg?label=NuGet)](https://www.nuget.org/packages/Zebble.Sharing/)

> This plugin make you able to set clipboard and share somthing in an easy way on Android, IOS, and UWP platforms in Zebble Apps.

<br>


### Setup
* Available on NuGet: [https://www.nuget.org/packages/Zebble.Sharing/](https://www.nuget.org/packages/Zebble.Sharing/)
* Install in your platform client projects.
* Available for iOS, Android and UWP.
<br>


### Api Usage
Call `Zebble.Device.Sharing` from any project to gain access to APIs.

##### Share:

The following code will open a dialog allowing the user to select a media to share some text or URL.
```csharp
await Zebble.Device.Sharing.Share(text: "My Message", title: "My Title", url: "http://example.com");

// Note: You should provide at least one of the parameters.
```
For example, you can call it in the event handler of a button reading "Share".

##### SetClipboard:
The following code allows you to copy some text into clipboard:
```csharp
await Device.Sharing.SetClipboard("some text");
```
Android allows you to specify a label for the clipboard as well. If you want to use that feature then you can use the following overload:
```csharp
await Device.Sharing.SetClipboard("some text", "android specific label");
```
// Note: the label will be ignored in iOS and Windows platforms.
<br>

### Methods
| Method       | Return Type  | Parameters                          | Android | iOS | Windows |
| :----------- | :----------- | :-----------                        | :------ | :-- | :------ |
| Share         | Task<bool&gt;| text -> string<br> title -> string<br> url -> string<br> androidChooserTitle -> string<br> iosExclude -> DeviceSharingOption<br> errorAction -> OnError| x       | x   | x       |
| SetClipboard         | Task<bool&gt;| text -> string<br> errorAction -> OnError| x       | x   | x       |
| SupportsClipboard |Task<bool&gt;| errorAction -> OnError| x       | x   | x       |