pipeline {
    agent any

   environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = 'true' // Optional: Disable telemetry
    }

    stages {
                stage('Checkout') {
            steps {
                // Checkout your source code from your version control system (e.g., Git)
                git 'https://github.com/yourusername/your-repository.git'
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