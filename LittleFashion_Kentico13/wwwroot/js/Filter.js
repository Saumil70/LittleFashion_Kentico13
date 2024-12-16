function filterProductByCategory() {
    var selectedCategories = [];

    // Collect all selected checkboxes
    $('input[name="categories"]:checked').each(function () {
        selectedCategories.push($(this).val());
    });

    // Perform the AJAX request to filter products and get the updated Index view
    $.ajax({
        url: '/InventoryPage/FilterByCategory',
        type: 'POST',
        data: { categories: selectedCategories },
        success: function (result) {
            $('#product-listings').html(result);
            console.log("Successfully filtered the products");
        },
        error: function () {
            console.log("An error occurred while filtering the products.");
        }
    });
}


function filterByPrice(values) {

    $.ajax({
        url: '/InventoryPage/FilterByPrice',
        type: 'POST',
        data: { pricerange: values },
        success: function (result) {
            $('#product-listings').html(result);
            console.log("Successfully filtered the products");
        },
        error: function () {
            console.log("An error occurred while filtering the products.");
        }
    });
}

