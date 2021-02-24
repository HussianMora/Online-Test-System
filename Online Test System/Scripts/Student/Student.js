function saveStudentScore() {
    //var testScore = getStudentTotalScore();
    var testData = {
        TestScore: getStudentTotalScore(),
        TotalQuestions: parseInt($('#hdnTotalQuestions').val()),
    };
    $.ajax({
        type: "POST",
        url: '/Student/SaveStudentTestDetails',
        data: { test: testData },
        success: function (result) {
            window.location.href = '/Student/TestCompleted/';
        }
    });
}

function getStudentTotalScore() {
    var totalScore = 0;
    for (i = 1; i <= $('#hdnTotalQuestions').val() ; i++) {
        if ($('input[name="' + i + '"]:checked').val() == $('#CorrectAnswer_' + i + '').val()) {
            totalScore++;
        }
    }
    return totalScore;
}