function validateImpact() {
    var value = document.getElementById('txtImpactName').value.trim();
    if (value === '') {
        alert("Impact name should not be empty");
        return false;
    }
    else {
        return true;
    }
}