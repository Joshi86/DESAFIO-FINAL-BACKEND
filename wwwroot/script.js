const api = "https://localhost:7122/api";

const token = localStorage.getItem("token");

if (!token) {
    window.location.href = "login.html";
}

const payload = JSON.parse(atob(token.split('.')[1]));

const role =
    payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

let modal;
let modalDisciplina;
let modalNota;
let modalVerNotas;

document.addEventListener("DOMContentLoaded", () => {

    modal = new bootstrap.Modal(document.getElementById('modalAluno'));

    modalDisciplina = new bootstrap.Modal(document.getElementById('modalDisciplina'));

    modalNota = new bootstrap.Modal(document.getElementById('modalNota'));

    modalVerNotas = new bootstrap.Modal(document.getElementById('modalVerNotas'));

    if (role !== "Admin") {

        document.getElementById("btnNovoAluno")
            .style.display = "none";
    }

    if (role === "Aluno") {

        document.getElementById("btnDisciplina")
            .style.display = "none";
    }

    carregarAlunos();
});


// ========================
// ALUNOS
// ========================

async function carregarAlunos() {

    const res = await fetch(`${api}/alunos`, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const alunos = await res.json();

    const tabela = document.getElementById("tabelaAlunos");

    tabela.innerHTML = "";

    alunos.forEach(a => {

    let botoes = "";

    // ADMIN
    if (role === "Admin") {

        botoes += `
            <button class="btn btn-warning btn-sm"
                onclick="editar(${a.id})">
                Editar
            </button>

            <button class="btn btn-danger btn-sm"
                onclick="deletar(${a.id})">
                Excluir
            </button>

            <button class="btn btn-success btn-sm"
                onclick="abrirNotas(${a.id})">
                Lançar Nota
            </button>
        `;
    }

    // PROFESSOR
    if (role === "Professor") {

        botoes += `
            <button class="btn btn-success btn-sm"
                onclick="abrirNotas(${a.id})">
                Lançar Nota
            </button>
        `;
    }

    // TODOS
    botoes += `
        <button class="btn btn-info btn-sm"
            onclick="verNotas(${a.id})">
            Ver Notas
        </button>
    `;

    tabela.innerHTML += `
        <tr>
            <td>${a.id}</td>
            <td>${a.nome}</td>
            <td>${a.cpf}</td>
            <td>${a.dataNascimento.split("T")[0]}</td>

            <td>
                ${botoes}
            </td>
        </tr>
    `;
});
}

function abrirFormulario() {

    document.getElementById("alunoId").value = "";
    document.getElementById("nome").value = "";
    document.getElementById("cpf").value = "";
    document.getElementById("dataNascimento").value = "";

    modal.show();
}

async function editar(id) {

    const res = await fetch(`${api}/alunos/${id}`, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const a = await res.json();

    document.getElementById("alunoId").value = a.id;
    document.getElementById("nome").value = a.nome;
    document.getElementById("cpf").value = a.cpf;
    document.getElementById("dataNascimento").value =
        a.dataNascimento.split("T")[0];

    modal.show();
}

async function salvarAluno() {

    const id = document.getElementById("alunoId").value;

    const nome = document.getElementById("nome").value.trim();

    const dataNascimento =
        document.getElementById("dataNascimento").value;

    if (nome === "") {

        document.getElementById("nome")
            .classList.add("is-invalid");

        return;
    }

    document.getElementById("nome")
        .classList.remove("is-invalid");

    const cpf = document.getElementById("cpf").value;

    const regexCpf = /^\d{3}\.\d{3}\.\d{3}\-\d{2}$/;

    if (!regexCpf.test(cpf)) {

        document.getElementById("cpf")
            .classList.add("is-invalid");

        return;
    }

    document.getElementById("cpf")
        .classList.remove("is-invalid");

    const cpfLimpo = cpf.replace(/\D/g, "");

    if (dataNascimento === "") {

        document.getElementById("dataNascimento")
            .classList.add("is-invalid");

        return;
    }

    document.getElementById("dataNascimento")
        .classList.remove("is-invalid");

    const dados = {
        nome,
        cpf: cpfLimpo,
        dataNascimento
    };


    if (id) {

        await fetch(`${api}/alunos/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(dados)
        });

    } else {

        await fetch(`${api}/alunos`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(dados)
        });
    }

    modal.hide();

    carregarAlunos();
}

async function deletar(id) {

    if (!confirm("Deseja excluir?"))
        return;

    await fetch(`${api}/alunos/${id}`, {
        method: "DELETE",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    carregarAlunos();
}

// ========================
// DISCIPLINAS
// ========================

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
            cargaHoraria: Number(cargaHoraria.value)
        })
    });

    modalDisciplina.hide();

    alert("Disciplina criada!");
}


// ========================
// NOTAS
// ========================

async function abrirNotas(alunoId) {

    document.getElementById("alunoNotaId").value = alunoId;

    const res = await fetch(`${api}/disciplina`, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const disciplinas = await res.json();

    const select =
        document.getElementById("disciplinaSelect");

    select.innerHTML = "";

    disciplinas.forEach(d => {

        select.innerHTML += `
            <option value="${d.id}">
                ${d.nome}
            </option>
        `;
    });

    modalNota.show();
}

async function salvarNota() {

    const alunoId =
        Number(document.getElementById("alunoNotaId").value);

    const disciplinaId =
        Number(document.getElementById("disciplinaSelect").value);

    const notaInput =
        document.getElementById("nota");

    if (notaInput.value.trim() === "") {

        notaInput.classList.add("is-invalid");

        return;
    }

    notaInput.classList.remove("is-invalid");

    const nota = Number(notaInput.value);

    if (nota < 0 || nota > 10 || isNaN(nota)) {

        notaInput.classList.add("is-invalid");

        return;
    }

    await fetch(`${api}/matricula/nota`, {
        method: "PUT",
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

    modalNota.hide();

    alert("Nota lançada!");

    console.log("Aluno:", alunoId);
    console.log("Disciplina:", disciplinaId);
    console.log("Nota:", nota);

}



// ========================
// VER NOTAS
// ========================

async function verNotas(alunoId) {

    const res = await fetch(`${api}/alunos/${alunoId}/notas`, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });

    const notas = await res.json();

    const tabela =
        document.getElementById("tabelaNotas");

    tabela.innerHTML = "";

    notas.forEach(n => {

        tabela.innerHTML += `
            <tr>
                <td>${n.disciplina}</td>
                <td>${n.nota}</td>
                <td>${n.situacao}</td>
            </tr>
        `;
    });

    modalVerNotas.show();
}

// ========================
// LOGOUT
// ========================

function logout() {

    localStorage.removeItem("token");

    window.location.href = "login.html";
}