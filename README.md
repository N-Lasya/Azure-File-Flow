# Azure-File-Flow

**Key Features of Azure FileOps:**

**File Processing and Validation:**

Reads files from an Azure Storage account.

Validates the files based on predefined rules (file format). If a file is valid, it is moved to a "Valid" folder; if invalid, it is transferred to an "Invalid" folder within the Azure Blob Storage.

**Data Ingestion into Azure Cosmos DB (MongoDB API):**

For valid files, data is extracted and inserted into Azure Cosmos DB using the MongoDB API.

**Scheduled Automation via Cron Job:**

A Cron job is scheduled to automatically trigger file validation and processing at regular intervals.
This job is deployed on Azure Kubernetes Service (AKS) to leverage containerized, scalable workloads.

**Acknowledgement Emails:**

Upon successful file processing (valid or invalid), an acknowledgment email is sent to notify relevant users about the status of the file.

**UI Integration using Angular:**

A front-end UI built with Angular displays data from the Cosmos DB.
The interface allows users to view processed data and track file statuses directly from the application.

**Tech Stack**

C# .net, Azure Storage Account, Azure Cosmos DB (Mongo DB), Azure Function App, Azure Logic App, AKS, Angular
