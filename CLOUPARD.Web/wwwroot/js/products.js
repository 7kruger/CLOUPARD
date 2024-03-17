const addProductModal = new bootstrap.Modal($("#addProductModal"), { keyboard: false });
const editProductModal = new bootstrap.Modal($("#editProductModal"), { keyboard: false });
const deleteProductModal = new bootstrap.Modal($("#deleteProductModal"), { keyboard: false });

$("#add").on("click", function () {
    const newProduct = {
        name: $("#productName").val(),
        description: $("#productDescription").val()
    }

    if (isEmpty(newProduct.name)) {
        $("#validation-message").text("Дайте название новой категории");
    } else {
        addProduct(newProduct);
    }
});

$("#products").on("click", "#editProduct", function () {
    let id = $(this).parent().parent().parent().parent().attr("id");
    let product = getProduct(id);

    if (product != null) {
        $("#editProductName").val(product.name);
        $("#editProductDescription").val(product.description)
        editProductModal.show();

        $("#saveChanges").on("click", function () {
            const editedProduct = {
                id: id,
                name: $("#editProductName").val(),
                description: $("#editProductDescription").val(),
            }

            if (isEmpty(editedProduct.name) || isEmpty(editedProduct.description)) {
                $("#edit-validation-message").text("Заполните поля правильно");
            } else {
                editProduct(editedProduct);
            }
        });

    } else {
        alert("Ошибка")
    }
});

$("#products").on("click", "#deleteProduct", function () {
    deleteProductModal.show();
    let id = $(this).parent().parent().parent().parent().attr("id");

    $("#confirmDelete").on("click", function () {
        deleteProduct(id);
    });
});

const addProduct = (product) => {
    $.ajax({
        type: "post",
        url: "/product/create",
        async: false,
        data: { name: product.name, description: product.description }
    }).done(() => {
        window.location.replace($(location).attr("href"));
    }).fail((e) => {
        $("#validation-message").text(e.responseText);
    });
}

const editProduct = (product) => {
    $.ajax({
        type: "put",
        url: "/product/update",
        async: false,
        data: { id: product.id, name: product.name, description: product.description }
    }).done(() => {
        window.location.replace($(location).attr("href"));
    }).fail((e) => {
        isEmpty(e.responseText) ? alert("Произогла ошибка при редактировании продукта") : $("#edit-validation-message").text(e.responseText);
    });
}

const getProduct = (id) => {
    let product;

    $.ajax({
        type: "get",
        url: `/product/GetProduct/${id}`,
        async: false
    }).done((data) => {
        if (data === null) {
            product = null;
        } else {
            product = {
                id: data.id,
                name: data.name,
                description: data.description
            }
        }
    }).fail((e) => {
        product = null;
    });

    return product;
}

const deleteProduct = (id) => {
    $.ajax({
        type: "delete",
        url: "/product/delete/" + id,
        async: false,
    }).done(() => {
        window.location.replace($(location).attr("href"));
    }).fail((e) => {
        isEmpty(e.responseText) ? alert("Произошла ошибка при удалении") : alert(e.responseText);
    });
}

$("#addProductModal [data-bs-dismiss=modal]").on("click", function () {
    $("#validation-message").text("");
    $("#productName").val("");
    $("#productDescription").val("");
});

$("#editProductModal [data-bs-dismiss=modal]").on("click", function () {
    $("#edit-validation-message").text("");
    $("#productName").val("");
    $("#productDescription").val("");
});

const isEmpty = (str) => str.trim() == '';