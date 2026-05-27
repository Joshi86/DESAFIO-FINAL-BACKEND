const api = "https://desafio-final-backend-1.onrender.com/api";

const token = localStorage.getItem("token");

if (!token) {

    window.location.href = "login.html";
}

async function carregarProfessores() {

    const res = await fetch(`${api}/usuarios`, {

        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const usuarios = await res.json();

    const professores =
        usuarios.filter(u => u.role === "Professor");

    const tabela =
        document.getElementById("tabelaProfessores");

    tabela.innerHTML = "";

    professores.forEach(p => {

        tabela.innerHTML += `
            <tr>
                <td>${p.id}</td>
                <td>${p.username}</td>
                <td>${p.role}</td>
            </tr>
        `;
    });
}

function mostrarLoading() {

    document
        .getElementById("loadingScreen")
        .classList.remove("hidden");
}

function esconderLoading() {

    document
        .getElementById("loadingScreen")
        .classList.add("hidden");
}

function logout() {

    localStorage.removeItem("token");

    window.location.href = "login.html";
}

carregarProfessores();