const tableSearch = () => {
    const phrase = document.getElementById("search");
    const table = document.getElementById("main-table");
    const regPhrase = new RegExp(phrase.value, "i");
    let flag;
    for (let i = 1; i < table.rows.length; i++) {
        flag = false;
        flag = regPhrase.test(table.rows[i].cells[0].innerHTML);
        if (flag) {
            table.rows[i].style.display = "";
        } else {
            table.rows[i].style.display = "none";
        }
    }
}