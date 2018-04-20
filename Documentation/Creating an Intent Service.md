# Creating a new Intent Service

## If you have the IntentService template installed in Visual Studio and Functioning properly

1. Select **File > New > Project > Visual C# > Intent Service**
1. [Continue at "Regardless of File Source"](#Regardless-of-File-Source)

## If you don't have the IntentService template

1. Copy the Intent Service files from the IntentBot samples at **...\IntentBot\Samples\NetCore20\IntentService.NetCore20** into a descriptively named folder (i.e. *MyIntentService*)
1. Optional steps to create distinct namespaces for each project:
    1. Rename the csproj file to match the folder name (i.e. *MyIntentService.csproj*)
    1. Open the project in Visual Studio
    1. If Visual Studio didn't already do it for you, adjust the project properties to match the folder name
        * Assembly Name
        * Default Namespace
    1. Adjust the namespacing in all files to match the folder name
        * Startup.cs
        * Program.cs
        * Controllers/ValuesController.cs (*Controllers.MyIntentService*)
1. [Continue at "Regardless of File Source"](#Regardless-of-File-Source)

## Regardless of File Source

1. Modify **Handlers/Handle.cs** to do the work and asynchronously return a *CommandResponse* object containing the appropriate response to the user. 
    * Primary data elments in the response are:
        * **ResultStatus** - Indicates whether or not the request was handled successfully, and if not, why. Options include:
            * **Success**
            * **RequestNotUnderstood**
            * **UserNotFound**
        * **ResponseText** - The textual response to be sent to the user.
    * Additional data elements in the response are (not all of these options may be handled by the bot at this point in time):
        * **RequiresUserConfirmation** - A flag that indicates that the user should respond with a confirmation or rejection of the response.
        * **IsAdditionalInformationAvailable** - A flag that indicates that the service could provide more information than it did. If supported, the bot should ask the user if they would like more information and call the additional information service if the user responds in the affirmative.
        * **UriResponse** - A URL or other link to be displayed to the user, properly formatted as a URI, as part of the response.
        * **PhoneNumberResponse** - A phone number to be displayed to the user, properly formatted as a phone number, as part of the response.
1. If the handler requires additional dependencies, they should be added to the container in the **ConfigureServices** method of the **Startup.cs** file.

## Publish the Service

1. Right-click on the project name in Visual Studio and select **Publish**
1. If a profile hasn't yet been created, create a Folder Profile
    * The folder should be set to **bin\Release\PublishOutput**
1. Click **Publish**


## Deploying to Cloud Foundry

1. Open a Powershell or Command window
1. Change into the folder the app was published to (**bin\Release\PublishOutput**)
1. If not already logged-in, login to the proper CF org & space using the **cf login** command
1. **cf push *MyIntentService* --no-route**
    * Bundle the service
1. **cf map-route *MyIntentService* apps.internal --hostname *MyIntentService***
    * This creates a private, internal-only route for the Intent Service
1. **cf add-network-policy *BotAppName* --destination-app *MyIntentService***
    * This allows the bot service to communicate with the Intent Service without having a public route
