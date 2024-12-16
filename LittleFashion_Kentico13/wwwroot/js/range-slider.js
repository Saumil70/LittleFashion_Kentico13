var slider = document.getElementById('priceSlider');

noUiSlider.create(slider, {
    start: [0, 200],
    connect: true,
    range: {
        'min': 0,
        'max': 200
    },
    tooltips: [true, true],
    format: {
        to: function (value) {
            return Math.round(value);
        },
        from: function (value) {
            return Number(value);
        }
    }
});

slider.noUiSlider.on('set', function (values) {
    console.log('Min Price:', values[0]);
    console.log('Max Price:', values[1]);

    filterByPrice(values);
});
