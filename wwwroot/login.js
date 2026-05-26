const api = "/api";
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
        document.getElementById("novoUsuario");

    const senha =
        document.getElementById("novaSenha");

    const role =
        document.getElementById("role").value;

    const aceiteLgpd =
        document.getElementById("aceiteLgpd");

    let valido = true;

    if (username.value.trim() === "") {

        username.classList.add("is-invalid");

        valido = false;

    } else {

        username.classList.remove("is-invalid");
    }

    if (senha.value.trim() === "") {

        senha.classList.add("is-invalid");

        valido = false;

    } else {

        senha.classList.remove("is-invalid");
    }

    if (!aceiteLgpd.checked) {

        aceiteLgpd.classList.add("is-invalid");

        valido = false;

    } else {

        aceiteLgpd.classList.remove("is-invalid");
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

                username: username.value,

                senha: senha.value,

                role: role
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