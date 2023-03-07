function focused() {
    let mainDiv = document.getElementsByTagName("div")[0];

    Array.from(mainDiv.getElementsByTagName("input")).forEach(element => {
        element.addEventListener("focus", () => {
            element.parentElement.classList.add("focused");
        });
        element.addEventListener("blur", () => {
            element.parentElement.classList.remove("focused");
        });
    });
}