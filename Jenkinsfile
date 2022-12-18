pipeline {
    agent any
    environment {
        NEW_VERSION = '1.3.0'
    }   
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
                    BRANCH_NAME == 'dev' || BRANCH_NAME == 'master'
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
                withCredentials([
                    usernamePassword(credentials: 'server-credentials', usernameVariable: USER, passwordVariable: PWD)
                ]){
                    sh "some script ${USER} ${PWD}"
                }
                echo "deploying version ${params.VERSION}"
            }
        }
    }
	post {
		
	}
}