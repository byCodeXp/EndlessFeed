module.exports = {
    mode: 'jit',
    content: ["./src/**/*.{html,jsx}"],
    theme: {
        extend: {
            gridTemplateColumns: {
                '24': 'repeat(24, minmax(0, 1fr))'
            }
        },
    },
    plugins: [],
}