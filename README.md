# Leaderboard API

A minimal RESTful API for managing game leaderboards, using in-memory storage. This API supports basic CRUD operations for player scores and is designed as an MVP (Minimum Viable Product) for game integration.

## Project Overview

This project implements a simple leaderboard system that:
- Stores player scores with timestamps
- Sorts the leaderboard by highest scores first
- Provides endpoints to create, retrieve and update score entries
- Uses in-memory storage (data is lost on restart)

## How to Run the Project

### Prerequisites
- .NET 8.0 SDK or later
- Visual Studio, Visual Studio Code, or any preferred IDE with C# support

### Running the Application
1. Clone the repository
2. Navigate to the project directory:
   ```
   cd /Users/ianphil/tmp/leaderboard
   ```
3. Run the application:
   ```
   dotnet run
   ```
4. The API will start on http://localhost:5056

## How to Access the Pong Game

This API can be integrated with any game that needs leaderboard functionality. For a Pong game integration:

1. Use the POST endpoint to submit player scores after each game:
   ```
   POST http://localhost:5056/api/leaderboard/scores
   ```

2. Display the leaderboard using the GET endpoint:
   ```
   GET http://localhost:5056/api/leaderboard/scores
   ```

3. Look up specific player scores:
   ```
   GET http://localhost:5056/api/leaderboard/scores/{playerId}
   ```

## Using HTTP Files for API Requests

This project includes HTTP request files in the `/Requests` folder that you can use to test the API endpoints.

### Prerequisites
- [REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) for Visual Studio Code

### Making Requests
1. Open VS Code
2. Install the REST Client extension if you haven't already
3. Open any `.http` file from the `/Requests` folder
4. Click the "Send Request" button that appears above each request

### Available Request Files
- `get-all-scores.http`: Retrieve all scores in the leaderboard
- `add-score.http`: Add a new score or update an existing one
- `get-player-score.http`: Get a specific player's score

Example:
```http
### Get all scores
GET http://localhost:5056/api/leaderboard/scores
```

Simply click the "Send Request" link above the request to execute it and see the response in VS Code.
