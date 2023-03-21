class Company {
    #departments;

    constructor() {
        this.#departments = {};
    }

    addEmployee(...args){
        for (const argument of args) {
            if(argument === '' || argument === null || argument === undefined){
                throw new Error('Invalid input!');
            }
        }

        let name, salary, position, department;
        [name, salary, position, department] = args;
        
        if(salary < 0){
            throw new Error('Invalid input!');
        }

        if(!this.#departments.hasOwnProperty(department)){
            this.#departments[department] = [];
        }

        const employee = {name: name, salary: salary, position: position};
        this.#departments[department].push(employee);

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){
        const avgSalaries = Object.entries(this.#departments)
            .reduce((object, currentValue) => {
                const departmentName = currentValue[0];
                const avgSalary = currentValue[1].reduce((result, employee) => {
                    result += employee.salary;
                    return result;
                }, 0) / currentValue[1].length;

                object[departmentName] = avgSalary;
                return object;
            }, {});
            
        const bestDepartment = Object.entries(avgSalaries)
            .sort((a, b) => b[1] - a[1])[0];

        let result = `Best Department is: ${bestDepartment[0]}\nAverage salary: ${bestDepartment[1].toFixed(2)}\n`;

        const employees = Object.values(this.#departments[bestDepartment[0]])
            .sort((a, b) => {
                if(a.salary - b.salary === 0){
                    return a.name.localeCompare(b.name);
                } else {
                    return b.salary - a.salary;
                }
            })
            .map(x => `${x.name} ${x.salary} ${x.position}`);
        
        result += employees.join('\n');
        return result;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());