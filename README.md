MapView-for-FoodTruck

Technical Track: Full Stack (a trivial back-end). The back-end sets up an API endpoint, /foodtrucks, that retrieves food trucks data from https://data.sfgov.org/resource/6a9r-agq8.json and sends it back to the front-end. The back-end is trivial in the sense that it does nothing beyond handing data from somewhere else to the front-end; I could have let the front-end directly talk to DataSF's API, which could also be faster than going through a backend. However, I chose to implement a trivial back-end because it allows more opportunities of code optimization. For example, assuming DataSF's food trucks data does not change very often, I can make the back-end store a copy of DataSF's data into its own database and periodically update that data, thereby speeding up data transfer to the front-end.

Technical Details:

The back-end is implemented with MVC 5. I learnt that a year ago by using it to build a simple dashboard. 

The front-end is implemented with Javascript. The main files to look at is MapView-for-FoodTruck/MapView/Views/Home/Index.cshtml


If I were to spend additional time, I would do the following:

1. Speed up loading food trucks data. I could do this in two ways. One, as mentioned above, make the back-end store a copy of DataSF's data into its own database and periodically update that data. In this way, the back-end can just query its own data and avoid talking to DataSF on every request from the front-end. Two, cache food truck data on the front-end in HTML5 local storage. (Right now the loading time is between 1 and 2 seconds, which could be significantly longer on slower networks. 

2. Provide results filtering feature. I would consider adding a filtering feature that lets user search for specific food and/or lets user filter out food trucks whose permits have expired.
3. A set of onboarding popups for first-time visitors to learn about the tool and how to use it.

Design Trade-offs: I decide to not include any title or description about the tool but make the map take up the whole page. Because this is a specific tool that does a specific task, I assume that most people who check out this tool already know what it is about. It may be good to display a set of onboarding popups for first-time visitors to learn about the tool and how to use it, but it may not be necessary to have a fixed section on the page that explains all this. A map that takes up the whole page, on the other hand, looks clean and simple. 
Testing: I did not write tests for this project. In my understanding of it, testing requires isolation from other systems. In other words, the thing that is being tested cannot rely on other system, because otherwise it is hard to test where an error comes from. Functions of this project do not have much computational logic, and the majority of them rely on other systems such as Google Maps API. In order to test, I may need to create mocks of google maps. 
