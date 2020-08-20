---
page_type: sample
languages:
- csharp
- javascript
- html
- java
- python
products:
- azure
description: "LUIS allows your application to understand what a person wants in their own words."
urlFragment: cognitive-services-language-understanding
---

# Language Understanding (LUIS) Samples

Welcome to the Language Understanding ([LUIS](https://azure.microsoft.com/en-us/services/cognitive-services/language-understanding-intelligent-service/)) samples repository. LUIS allows your application to understand what a person wants in their own words. LUIS uses machine learning to allow developers to build applications that can receive user input in natural language and extract meaning from it.

## Create your Azure LUIS service

Use the `Deploy to Azure` button to quickly create an Azure LUIS service. You get one free LUIS service per account. The free service has a sku of `F0`. The basic tier has a sku of `S0`.

## Documentation

[Documentation](https://docs.microsoft.com/azure/cognitive-services/luis) includes:

* Quickstarts 
* Tutorals
* [Developer center](https://docs.microsoft.com/azure/cognitive-services/luis/developer-reference-resource)
* [FAQs](https://docs.microsoft.com/azure/cognitive-services/LUIS/luis-resources-faq)
* [Regions](https://docs.microsoft.com/azure/cognitive-services/LUIS/luis-reference-regions)
* [Limits](https://docs.microsoft.com/azure/cognitive-services/LUIS/luis-boundaries)
* [Supported languages](https://docs.microsoft.com/azure/cognitive-services/LUIS/luis-supported-languages)

## Interactive app
Ask LUIS to turn on the lights in this [interactive demonstration](https://azure.microsoft.com/en-us/services/cognitive-services/language-understanding-intelligent-service/).

## Healthbot

Tell the [Contoso Health bot](https://healthbotcontainer.azurewebsites.net/) where you are injured and the bot will recommend remedies.

## Intelligent Kiosk

The open-source [Intelligent Kiosk Sample](https://github.com/Microsoft/Cognitive-Samples-IntelligentKiosk) version is a collection of apps showcasing workflows and experiences built on top of the Microsoft Cognitive Services. Most of the experiences are hands-free and autonomous, using the human faces in front of a web camera as the main form of input (thus the word "kiosk" in the name).

Install the currently supported Intelligent Kiosk as a [Windows 10 app](https://aka.ms/kioskapp) and try out the various apps inside the kiosk, including apps with LUIS. 

## SDKs 

last updated Feb 13, 2019

|Language|Package Manager|Samples|Reference Documentation|
|--|--|--|--|
|C#|  [NuGet - authoring](https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring/)<br>[NuGet - runtime](https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime/)|[Samples](https://github.com/Azure-Samples/cognitive-services-dotnet-sdk-samples/tree/master/LUIS)|[Docs](https://docs.microsoft.com/dotnet/api/overview/azure/cognitiveservices/client/languageunderstanding?view=azure-dotnet)|
|Go|[SDK - authoring](https://github.com/Azure/azure-sdk-for-go/tree/master/services/cognitiveservices/v2.0/luis/authoring)<br>[SDK - runtime](https://github.com/Azure/azure-sdk-for-go/tree/master/services/cognitiveservices/v2.0/luis/runtime)|-|[Docs](https://godoc.org/github.com/Azure/azure-sdk-for-go/services/cognitiveservices/v2.0/luis/)|
|Java|[Maven - authoring](https://search.maven.org/artifact/com.microsoft.azure.cognitiveservices/azure-cognitiveservices-luis-authoring)<br>[Maven - runtime](https://search.maven.org/artifact/com.microsoft.azure.cognitiveservices/azure-cognitiveservices-luis-runtime)|[Samples](https://github.com/Azure-Samples/cognitive-services-java-sdk-samples/tree/master/Language/LanguageUnderstanding)|[Docs](https://docs.microsoft.com/java/api/overview/azure/cognitiveservices/client/languageunderstanding?view=azure-java-stable)|
|Javascript|[NPM - authoring](https://www.npmjs.com/package/azure-cognitiveservices-luis-authoring)<br>[NPM - runtime](https://www.npmjs.com/package/azure-cognitiveservices-luis-runtime)|[Samples](https://github.com/Azure-Samples/cognitive-services-node-sdk-samples/tree/master/Samples/luis)||
|Python|[PIP](https://pypi.org/project/azure-cognitiveservices-language-luis/)|[Samples](https://github.com/Azure-Samples/cognitive-services-python-sdk-samples/tree/master/samples/language/luis)|[Docs](https://docs.microsoft.com/en-us/python/api/overview/azure/cognitiveservices/luis?view=azure-python)|
  
## Azure REST API

* [Swagger/OpenApi](https://github.com/Azure/azure-rest-api-specs/tree/master/specification/cognitiveservices/data-plane/LUIS)


## Azure CLI
* [Cognitive Services](https://aka.ms/az-cli-cognitiveservices)

## Azure RM Powershell
* [Cognitive Services](https://aka.ms/azure-powershell-cognitiveservices)

## Bots
* [Bot Framework](https://docs.microsoft.com/bot-framework/)
* BotBuilder
    * [Nodejs](https://github.com/Microsoft/botbuilder-js)
    * [.NET](https://github.com/Microsoft/botbuilder-dotnet)
* [Bot Builder Samples](https://github.com/Microsoft/BotBuilder-Samples)
* [Bot Builder Tools](https://github.com/Microsoft/botbuilder-tools)

## Related Services
* [QnA Maker](https://qnamaker.ai/)
* [Speech API](https://azure.microsoft.com/services/cognitive-services/speech/)

## Dependencies
* [Recognizers-Text](https://github.com/Microsoft/Recognizers-Text) for prebuilt entities

## Azure status
[Regional availability](https://azure.microsoft.com/global-infrastructure/services/): LUIS is part of the AI and Machine Learning section.


## Related Microsoft Projects

* [Prebuilt entity recognizer](https://github.com/Microsoft/Recognizers-Text)
* [Azure Code Samples for LUIS](https://azure.microsoft.com/resources/samples/?sort=0&term=Luis)
* [Universal Language Intelligence Service - Nodejs](https://github.com/Microsoft/Universal-Language-Intelligence-Service): A wrapper for the Microsoft LUIS cognitive that provides universal language support (after training) using the Bing Translate API
* [Microsoft Cognitive Services control for Microsoft Bot Builder - C# & Nodejs](https://github.com/Microsoft/BotBuilder-CognitiveServices): The cognitive services control makes consuming different Microsoft Cognitive Services easy for bots developed using Microsoft Bot Builder SDK. The control is available for C# and Node.js SDKs.
* [Activate Azure with Intelligent Apps - C#](https://github.com/Microsoft/intelligent-apps): Fabrikam Investment Bank Customer Service uses LUIS
* [LUIS Console Application Sample - C#](https://github.com/Azure-Samples/Cognitive-Services-LUIS-Console-Application)
* [Adaptive Cards](https://github.com/Microsoft/AdaptiveCards/)
* [Octobot from the Sandbox](https://docs.microsoft.com/sandbox/demos/octobot)

## Searching docs
* [Azure RSS for 'LUIS'](https://docs.microsoft.com/api/search/rss?search=LUIS&locale=en-us)

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

