pipeline {
    agent any      
    parameters {
        choice(name: 'VERSION', choices: ['1.1.0','1.2.0','1.3.0'], description: '')
        booleanParam(name: 'executeTests', defaultValue: true, description: '')
    }
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                echo "buildin version ${NEW_VERSION}"
            }
        }
        stage('Test') {
            when {
                expression {
                    params.executeTests
                }
            }
            steps {
                echo 'Testing..'
            }

        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'                
                echo "deploying version ${params.VERSION}"
            }
        }
    }	
}