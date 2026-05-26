const api = "/api";

const token = localStorage.getItem("token");

if (!token) {

    window.location.href = "login.html";
}

const payload = JSON.parse(atob(token.split('.')[1]));

const role = payload.role;

console.log(payload);

let modalDisciplina;

document.addEventListener("DOMContentLoaded", () => {

    modalDisciplina =
        new bootstrap.Modal(
            document.getElementById('modalDisciplina')
        );

    if (role === "Aluno") {

        document.getElementById("btnNovaDisciplina")
            .style.display = "none";
    }

    carregarDisciplinas();
});

async function carregarDisciplinas() {

    const res = await fetch(`${api}/disciplina`, {

        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const disciplinas = await res.json();

    const tabela =
        document.getElementById("tabelaDisciplinas");

    tabela.innerHTML = "";

    disciplinas.forEach(d => {

        tabela.innerHTML += `
            <tr>
                <td>${d.id}</td>
                <td>${d.nome}</td>
                <td>${d.cargaHoraria}</td>
            </tr>
        `;
    });
}

function abrirDisciplina() {

    document.getElementById("disciplinaNome").value = "";

    document.getElementById("cargaHoraria").value = "";

    modalDisciplina.show();
}

async function salvarDisciplina() {

    const nome =
        document.getElementById("disciplinaNome");

    const cargaHoraria =
        document.getElementById("cargaHoraria");

    let valido = true;

    if (nome.value.trim() === "") {

        nome.classList.add("is-invalid");

        valido = false;

    } else {

        nome.classList.remove("is-invalid");
    }

    if (cargaHoraria.value.trim() === "") {

        cargaHoraria.classList.add("is-invalid");

        valido = false;

    } else {

        cargaHoraria.classList.remove("is-invalid");
    }

    if (!valido)
        return;

    await fetch(`${api}/disciplina`, {

        method: "POST",

        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },

        body: JSON.stringify({

            nome: nome.value,

            cargaHoraria:
                Number(cargaHoraria.value)
        })
    });

    modalDisciplina.hide();

    carregarDisciplinas();
}

function logout() {

    localStorage.removeItem("token");

    window.location.href = "login.html";
}