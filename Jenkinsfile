pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = 'true' // Optional: Disable telemetry
    }

    stages {
        stage('Checkout') {
            steps {
                // Checkout your source code from your version control system (e.g., Git)
                git 'https://github.com/sgelaa/2023.git'
            }
        }

        stage('Restore') {
            steps {
                // Restore dependencies using .NET CLI
                script {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                // Build the .NET Core application
                script {
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                // Run tests for the .NET Core application
                script {
                    sh 'dotnet test --configuration Release --no-build'
                }
            }
        }

        stage('Publish') {
            steps {
                // Publish the .NET Core application
                script {
                    sh 'dotnet publish --configuration Release --output ./publish'
                }
            }
        }

        stage('Deploy') {
            steps {
                // Example deployment step
                // This could be deploying to a server, container, or any other deployment process
                // Adjust this step according to your deployment requirements
                // For example, if deploying to Azure, you might use Azure CLI commands here
                script {
                    sh 'echo "Deploying..."'

            // Deploy to IIS
                // # Define the variables
                $websiteName = "YourWebsiteName"
                $publishFolder = "./publish"
                $physicalPath = "C:\\inetpub\\wwwroot\\$websiteName"

                // # Create the website if it doesn't exist
                if (-not (Test-Path "IIS:\Sites\$websiteName")) {
                    New-WebSite -Name $websiteName -Port 80 -PhysicalPath $physicalPath
                }

                // # Stop the website before deploying
                Stop-WebSite -Name $websiteName

                // # Remove the content from the physical path
                Remove-Item "$physicalPath\*" -Force -Recurse

                // # Copy the published files to the physical path
                Copy-Item "$publishFolder\*" -Destination $physicalPath -Recurse

                // # Start the website after deployment
                Start-WebSite -Name $websiteName

                }
            }
        }
    }

        post {
        success {
            // This block will execute if the pipeline succeeds
            // You can include notifications, cleanup steps, etc.
            echo 'Pipeline succeeded!'
        }
        failure {
            // This block will execute if the pipeline fails
            // You can include notifications, cleanup steps, etc.
            echo 'Pipeline failed!'
        }
        }
}
