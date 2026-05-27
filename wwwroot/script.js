const api = "https://desafio-final-backend-1.onrender.com/api";
const token = localStorage.getItem("token");

const payload = JSON.parse(atob(token.split('.')[1]));

const role = payload.role;

console.log(role);

if (!token) {
    window.location.href = "login.html";
}

document.addEventListener("DOMContentLoaded", () => {

    esconderParaAluno("btnNovoAluno");
    carregarAlunos();
});

function esconderParaAluno(id) {

    const el = document.getElementById(id);

    if (!el) return;

    if (role === "Aluno") {
        el.style.display = "none";
    }
}

function abrirLoading() {

    document
        .getElementById("loadingScreen")
        .classList.remove("d-none");
}

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

    console.log(alunos);

    const tabela = document.getElementById("tabelaAlunos");

    tabela.innerHTML = "";

    alunos.forEach(a => {

        let botoes = "";

        if (role === "Admin" || role === "Professor") {

            botoes += `
                <button class="btn btn-warning btn-sm"
                    onclick="editar(${a.id})">
                    Editar
                </button>

                <button class="btn btn-danger btn-sm"
                    onclick="deletar(${a.id})">
                    Excluir
                </button>
            `;
        }

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

    const modalElement =
        document.getElementById('modalAluno');

    const modal =
        new bootstrap.Modal(modalElement);

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

    const modalElement =
        document.getElementById('modalAluno');

    const modal =
        bootstrap.Modal.getInstance(modalElement);

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
// LOGOUT
// ========================

function logout() {

    localStorage.removeItem("token");

    window.location.href = "login.html";
}