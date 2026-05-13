const api = "https://localhost:7122/api";

async function login() {

    const usuario =
        document.getElementById("usuario").value;

    const senha =
        document.getElementById("senha").value;

    try {

        const res = await fetch(`${api}/auth/login`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                usuario,
                senha
            })
        });

        if (!res.ok)
            throw new Error();

        const data = await res.json();

        localStorage.setItem("token", data.token);

        window.location.href = "home.html";

    } catch {

        document.getElementById("erro").innerText =
            "Usuário ou senha inválidos";
    }
}

let modalCadastro;

document.addEventListener("DOMContentLoaded", () => {
    modalCadastro = new bootstrap.Modal(document.getElementById('modalCadastro'));
});

function mostrarCadastro() {
    modalCadastro.show();
}

async function cadastrar() {

    const username =
        document.getElementById("novoUsuario").value;

    const senha =
        document.getElementById("novaSenha").value;

    const usernameInput =
        document.getElementById("novoUsuario");

    const senhaInput =
        document.getElementById("novaSenha");

    let valido = true;

    if (username.trim() === "") {

        usernameInput.classList.add("is-invalid");

        valido = false;

    } else {

        usernameInput.classList.remove("is-invalid");
    }

    if (senha.trim() === "") {

        senhaInput.classList.add("is-invalid");

        valido = false;

    } else {

        senhaInput.classList.remove("is-invalid");
    }

    if (!valido)
        return;

    try {

        const res = await fetch(`${api}/auth/register`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                username,
                senha
            })
        });

        if (!res.ok) {

            const msg = await res.text();

            throw new Error(msg);
        }

        alert("Usuário cadastrado!");

        modalCadastro.hide();

    } catch (e) {

        alert(e.message);
    }
}