function solve(input){
    const students = [];

    for (const line of input) { 
        const tokens = line.split(', '); 

        const student = {};
        for (const kv of tokens) {
            const keyValue = kv.split(': ');

            const key = keyValue[0];
            const parsed = parseFloat(keyValue[1]);
            student[key] = isNaN(parsed) ? keyValue[1] : parsed;
        }
        students.push(student);
    }

    const grades = students
        .map(s => s.Grade)
        .sort((a, b) => a - b);

    const uniqueGrades = [...new Set(grades)];
    const avgProperty = 'Graduated with an average score';

    for(let i = 0; i < uniqueGrades.length; i++){
        const grade = uniqueGrades[i];

        const filteredStudents = students
            .filter(s => s[avgProperty] >= 3 && s.Grade === grade);

        if(filteredStudents.length > 0){
            printClassInfo(grade, filteredStudents);
        }
    }

    function printClassInfo(grade, filteredStudents){
        let result = '';
        
        const names = filteredStudents.map(s => s['Student name']);
        const avgScore = filteredStudents
            .reduce((a, b) => a + b[avgProperty], 0) / filteredStudents.length;

        result += `${grade + 1} Grade\n`;
        result += `List of students: ${names.join(', ')}\n`;
        result += `Average annual score from last year: ${avgScore.toFixed(2)}\n`;

        console.log(result);
    }
}