//QUESTIONS FUNCTIONS
//Using fetch to contact the API and get the questions values
function getQuestions() {
    fetch("https://localhost:44387/api/Questions") // default: GET!
        .then(response => response.json()) // generates an object with the list of questions
        .then(questions => showQuestions(questions));
}

function showQuestions(questionsObj) {
    for (var i = 0; i < questionsObj.length; i++) {
        document.getElementById("listQuestions").innerHTML +=
            '<tr><td>' + questionsObj[i].id + '</td>' +
            '<td>' + questionsObj[i].description + '</td>' +
            '<td>' + questionsObj[i].answerId + '</td>' +
            '<td>' + questionsObj[i].categoryId + '</td></tr>';
    }
}

//Searches questions by text with the value inputed
function getQuestionByText() {
    fetch("https://localhost:44387/Questions/GetByText/" + document.getElementById("inp").value)
        .then(response => response.json())
        .then(questionByText => listByText(questionByText))
}

function listByText(questionObj) {
    for (var i = 0; i < questionObj.length; i++) {
        document.getElementById("byText").innerHTML +=
            '<p>' + questionObj[i].description + '</p>';
    }
}

//ANSWER QUESTIONS
//Using fetch to contact the API and get the questions values
function getAnswers() {
    fetch("https://localhost:44387/api/Answers") // default: GET!
        .then(response => response.json()) // generates an object with the list of questions
        .then(answers => showAnswers(answers));
}

function showAnswers(answersObj) {
    for (var i = 0; i < answersObj.length; i++) {
        document.getElementById("listAnswers").innerHTML +=
            '<p>' + answersObj[i].description + '</p>';
    }
}

//Searches questions by text with the value inputed
function getAnswerByText() {
    fetch("https://localhost:44387/Answers/GetByText/" + document.getElementById("inp").value)
        .then(response => response.json())
        .then(answerByText => listByText(answerByText))
}

function listByText(answerObj) {
    for (var i = 0; i < answerObj.length; i++) {
        document.getElementById("byText").innerHTML +=
            '<p>' + answerObj[i].description + '</p>';
    }
}

//CATEGORIES FUNCTIONS
//Using fetch to contact the API and get the questions values
function getCategories() {
    fetch("https://localhost:44387/api/Categories") // default: GET!
        .then(response => response.json()) // generates an object with the list of questions
        .then(categories => showCategories(categories));
}

function showCategories(categoriesObj) {
    for (var i = 0; i < categoriesObj.length; i++) {
        document.getElementById("listCategories").innerHTML +=
            '<p>' + categoriesObj[i].description + '</p>';
    }
}

//Searches questions by text with the value inputed
function getCategoryByText() {
    fetch("https://localhost:44387/Categories/GetByText/" + document.getElementById("inp").value)
        .then(response => response.json())
        .then(categoryByText => listByText(categoryByText))
}

function listByText(categoryObj) {
    for (var i = 0; i < categoryObj.length; i++) {
        document.getElementById("byText").innerHTML +=
            '<p>' + categoryObj[i].description + '</p>';
    }
}