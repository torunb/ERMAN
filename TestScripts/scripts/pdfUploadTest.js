document.querySelector("#btn").addEventListener("click", async () => {
    const fileInput = document.getElementById('file');
    const file = fileInput.files[0];
    
    const formData = new FormData();
    formData.append("file", file);

    await fetch("https://localhost:7073/api/Upload", {method: "POST", body: formData});
});
