function filterProducts() {
    var selectedCategories = [];

    // Collect all selected checkboxes
    $('input[name="categories"]:checked').each(function () {
        selectedCategories.push($(this).val());
    });

    // Perform the AJAX request to filter products and get the updated Index view
    $.ajax({
        url: '/InventoryPage/FilterProducts',
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