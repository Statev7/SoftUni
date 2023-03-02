function meating(data){
    const schedule = {};

    for (const index in data) {
       let line = data[index];

       const tokens = line.split(' ');
       const dayOfWeek = tokens[0];
       const employeeName = tokens[1];

       if(schedule[dayOfWeek] == undefined){
            schedule[dayOfWeek] = employeeName;
            console.log(`Scheduled for ${dayOfWeek}`)
       } else {
            console.log(`Conflict on ${dayOfWeek}!`)
       }
    }

    for (const day in schedule) {
        console.log(`${day} -> ${schedule[day]}`);
    }
}