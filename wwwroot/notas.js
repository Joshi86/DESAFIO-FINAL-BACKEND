const api = "https://desafio-final-backend-1.onrender.com/api";

const token = localStorage.getItem("token");

if (!token) {
    window.location.href = "login.html";
}

let modalNota;

let editandoId = null;

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

document.addEventListener("DOMContentLoaded", () => {
    mostrarLoading();

    modalNota = new bootstrap.Modal(
        document.getElementById("modalNota")
    );

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

    setTimeout(() => {
        esconderLoading();
    }, 700);
});

function abrirLoading() {

    document
        .getElementById("loadingScreen")
        .classList.remove("d-none");
}

// ========================
// LISTAR NOTAS
// ========================

async function carregarNotas() {

    try {

        const res = await fetch(`${api}/notas`, {
            headers: {
                "Authorization": `Bearer ${token}`
            }
        });

        if (!res.ok) {
            throw new Error("Erro ao carregar notas");
        }

        const notas = await res.json();

        const tabela = document.getElementById("tabelaNotas");

        tabela.innerHTML = "";

        notas.forEach(n => {

            tabela.innerHTML += `
                <tr>
                    <td>${n.aluno}</td>
                    <td>${n.disciplina}</td>
                    <td>${n.nota}</td>

                    <td>
                        <button 
                            class="btn btn-warning btn-sm"
                            onclick='editarNota(${JSON.stringify(n)})'>
                            Editar
                        </button>

                        <button 
                            class="btn btn-danger btn-sm"
                            onclick="deletarNota(${n.id})">
                            Excluir
                        </button>
                    </td>
                </tr>
            `;
        });

    } catch (erro) {

        console.log(erro);

        alert("Erro ao carregar notas");
    }
}


// ========================
// ABRIR MODAL
// ========================

function abrirModalNota() {

    limparCampos();

    editandoId = null;

    document.querySelector(".modal-title")
        .innerText = "Nova Nota";

    modalNota.show();
}


// ========================
// EDITAR NOTA
// ========================

function editarNota(nota) {

    editandoId = nota.id;

    document.getElementById("alunoSelect").value =
        nota.alunoId;

    document.getElementById("disciplinaSelect").value =
        nota.disciplinaId;

    document.getElementById("valorNota").value =
        nota.nota;

    document.querySelector(".modal-title")
        .innerText = "Editar Nota";

    modalNota.show();
}


// ========================
// SALVAR NOTA
// ========================

async function salvarNota() {

    const alunoId =
        Number(document.getElementById("alunoSelect").value);

    const disciplinaId =
        Number(document.getElementById("disciplinaSelect").value);

    const notaInput =
        document.getElementById("valorNota");

    const nota =
        Number(notaInput.value);

    if (nota < 0 || nota > 10) {

        notaInput.classList.add("is-invalid");

        return;
    }

    notaInput.classList.remove("is-invalid");

    const body = {
        alunoId,
        disciplinaId,
        nota
    };

    let url = `${api}/notas`;

    let method = "POST";

    if (editandoId !== null) {

        url = `${api}/notas/${editandoId}`;

        method = "PUT";
    }

    try {

        const res = await fetch(url, {
            method,
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(body)
        });

        if (!res.ok) {

            const erro = await res.text();

            console.log(erro);

            alert("Erro ao salvar nota");

            return;
        }

        modalNota.hide();

        carregarNotas();

    } catch (erro) {

        console.log(erro);

        alert("Erro ao salvar nota");
    }
}


// ========================
// DELETAR NOTA
// ========================

async function deletarNota(id) {

    const confirmar = confirm(
        "Deseja realmente excluir esta nota?"
    );

    if (!confirmar)
        return;

    try {

        const res = await fetch(`${api}/notas/${id}`, {
            method: "DELETE",
            headers: {
                "Authorization": `Bearer ${token}`
            }
        });

        if (!res.ok) {

            alert("Erro ao excluir nota");

            return;
        }

        carregarNotas();

    } catch (erro) {

        console.log(erro);

        alert("Erro ao excluir nota");
    }
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

    select.innerHTML =
        `<option value="">Selecione um aluno</option>`;

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

    const select =
        document.getElementById("disciplinaSelect");

    select.innerHTML =
        `<option value="">Selecione uma disciplina</option>`;

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