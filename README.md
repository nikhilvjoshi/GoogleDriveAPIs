# Google Drive API Examples & Live Implementations
This repository contains a collection of practical examples and live implementations using the Google Drive API. It demonstrates how to interact with Google Drive, including operations like file management (upload, download, delete, update), folder management, and metadata retrieval. Whether you're looking to automate workflows, integrate Google Drive into your application, or simply explore Google’s powerful API, this repo provides easy-to-follow code and working examples in multiple programming languages.

Features:
1. Authentication and authorization with Google Drive API (OAuth 2.0)
2. Create, list, update, and delete files and folders
3. Search for files/folders and check for their existence
4. File upload/download with support for various formats
5. Handling file permissions and sharing settings

# Languages Supported:
C#

To configure a project in the Google Cloud Console, follow these steps. This process involves creating a new project, enabling APIs, and setting up credentials (OAuth 2.0) for your application.

# Step 1: Create a New Project
1. Go to the Google Cloud Console:
2. Open the Google Cloud Console.

# Sign in:
1 Log in with your Google account if you haven’t already.

# Create a New Project:

1. Click on the "Select a project" dropdown at the top of the page.
2. Click on "New Project".
3. Enter a project name (e.g., "My Google Drive API Project").
4. Choose a billing account (if required) and location (you can leave it as "No organization" if you don’t have an organization set up) Click Create.
5. After creating the project, you will be automatically directed to the project dashboard.

# Step 2: Enable the Google Drive API
1. Navigate to the "API & Services" Dashboard:
2. From the left sidebar, go to APIs & Services > Dashboard.
3. Enable the Google Drive API:
4. Click on "+ ENABLE APIS AND SERVICES" at the top of the dashboard.
5. Search for Google Drive API in the search bar.
6. Click on Google Drive API from the results.
7. Click the Enable button.

# Step 3: Create OAuth 2.0 Credentials
1. Go to "Credentials":

In the left sidebar, go to APIs & Services > Credentials.
# Create Credentials:

1. Click on Create Credentials at the top of the page.
2. Select OAuth 2.0 Client ID.
3. Configure the OAuth Consent Screen:

You’ll be prompted to configure the OAuth consent screen.
Select an "External" User Type if you're going to use the API outside of your organization (or select "Internal" if it’s only for your organization).
Fill out the required fields like App name, User support email, and Developer contact information.
Under Scopes, you can leave the default settings unless you want to customize the access scope.
Click Save and Continue when done.
# Create OAuth Client ID:

Now, you'll be asked to configure the OAuth 2.0 client:
**Application type:** Select Web application (or other options if applicable).
**Name:** Give your client ID a name (e.g., "My Drive API App").
**Authorized redirect URIs:** Add the redirect URI for your application (this is required if you're using OAuth to authenticate). For a local development environment, you might use something like http://localhost:8080/ (adjust as needed).
Click Create.
**Download Credentials:**

After creating the credentials, you will see a Client ID and Client Secret.
Click Download to save the credentials.json file to your local machine. This file contains the credentials your app needs to authenticate via OAuth 2.0.

# Step 4: Set Up Billing (Optional)
If your application exceeds the free tier of Google APIs, you may need to set up billing. Google provides a free tier for many services, but you may need to enable billing if you need more resources. To do this:

Go to the Billing section in the Google Cloud Console.
Set up a billing account and link it to your project.

# Step 5: Use the API in Your Application
Now that your project is set up, you can start using the Google Drive API with the credentials.json file.

API Client Libraries: Download the relevant Google API client library for your language (Python, Java, Node.js, C#, etc.) from the Google API Client Libraries page.
Use the credentials.json file to authenticate your app and begin interacting with Google Drive.

Feel free to explore, fork, and contribute. Whether you're a beginner or an advanced developer, this repo can help you get started with integrating Google Drive into your projects!
