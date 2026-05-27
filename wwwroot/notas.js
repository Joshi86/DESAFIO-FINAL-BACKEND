const api = "https://desafio-final-backend-1.onrender.com/api";

const token = localStorage.getItem("token");

if (!token) {
    window.location.href = "login.html";
}

let modalNota;

document.addEventListener("DOMContentLoaded", () => {

    modalNota = new bootstrap.Modal(document.getElementById("modalNota"));

    const payload = JSON.parse(atob(token.split('.')[1]));

    const role =
        payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

    if (role === "Aluno") {

        document.getElementById("btnNovaNota")
            .style.display = "none";
    }


    carregarNotas();
    carregarAlunos();
    carregarDisciplinas();
});


// ========================
// NOTAS - LISTAR
// ========================

async function carregarNotas() {

    const res = await fetch(`${api}/notas`, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const notas = await res.json();

    const tabela = document.getElementById("tabelaNotas");

    tabela.innerHTML = "";

    notas.forEach(n => {

        tabela.innerHTML += `
            <tr>
                <td>${n.aluno}</td>
                <td>${n.disciplina}</td>
                <td>${n.nota}</td>
            </tr>
        `;
    });
}


// ========================
// ABRIR MODAL
// ========================

function abrirModalNota() {
    limparCampos();
    modalNota.show();
}


// ========================
// SALVAR NOTA
// ========================

async function salvarNota() {

    const alunoId = Number(document.getElementById("alunoSelect").value);

    const disciplinaId = Number(document.getElementById("disciplinaSelect").value);

    const notaInput = document.getElementById("valorNota");

    const nota = Number(notaInput.value);

    const res = await fetch(`${api}/notas`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify({
            alunoId,
            disciplinaId,
            nota
        })
    });

    if (!res.ok) {

        const erro = await res.text();

        console.log(erro);

        alert("Erro ao salvar nota");

        return;
    }

    modalNota.hide();

    carregarNotas();
}



// ========================
// CARREGAR ALUNOS
// ========================

async function carregarAlunos() {

    const res = await fetch(`${api}/alunos`, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const alunos = await res.json();

    const select = document.getElementById("alunoSelect");

    select.innerHTML = `<option value="">Selecione um aluno</option>`;

    alunos.forEach(a => {

        select.innerHTML += `
            <option value="${a.id}">
                ${a.nome}
            </option>
        `;
    });
}


// ========================
// CARREGAR DISCIPLINAS
// ========================

async function carregarDisciplinas() {

    const res = await fetch(`${api}/disciplina`, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const disciplinas = await res.json();

    const select = document.getElementById("disciplinaSelect");

    select.innerHTML = `<option value="">Selecione uma disciplina</option>`;

    disciplinas.forEach(d => {

        select.innerHTML += `
            <option value="${d.id}">
                ${d.nome}
            </option>
        `;
    });
}


// ========================
// LIMPAR CAMPOS
// ========================

function limparCampos() {

    document.getElementById("alunoSelect").value = "";
    document.getElementById("disciplinaSelect").value = "";
    document.getElementById("valorNota").value = "";

    document.getElementById("valorNota")
        .classList.remove("is-invalid");
}


// ========================
// LOGOUT
// ========================

function logout() {

    localStorage.removeItem("token");

    window.location.href = "login.html";
}