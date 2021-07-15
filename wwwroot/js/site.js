function readMoreFunction() {
    var dots = document.getElementById("dots");
    var moreText = document.getElementById("more");
    var btnText = document.getElementById("myBtn");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "Read more";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "Read less";
        moreText.style.display = "inline";
    }
}

function artistStatusColor() {
    var status = document.getElementById("statusColor");

    if (status.innerHTML === "Active") {
        status.classList.add("badge-success");
    } else if (status.innerHTML === "Split-up") {
        status.classList.add("badge-danger");
    } else if (status.innerHTML === "On hold") {
        status.classList.add("badge-primary");
    } else if (status.innerHTML === "Changed name") {
        status.classList.add("badge-info");
    } else if (status.innerHTML === "Unknown") {
        status.classList.add("badge-secondary");
    } else {
        status.classList.add("badge-dark");
    }
}

window.onload = artistStatusColor;