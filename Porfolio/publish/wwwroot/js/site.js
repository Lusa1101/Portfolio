// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById('darkModeToggle').addEventListener('click', () => {
    document.body.classList.toggle('dark-mode');
    localStorage.setItem('darkMode', document.body.classList.contains('dark-mode'));
});

if (localStorage.getItem('darkMode') === 'true') {
    document.body.classList.add('dark-mode');
}

const cnavas = document.getElementById("matrix");
const ctx = canvas.getContext("2d");

canvas.width = window.innerWidth;
cnavas.height = window.innerHeight;

const matrixChars = "01";
const fontSize = 16;

const columns = canvas.width / fontSize;
const drops = Array.from({ length: columns }).fill(1);

const draw = () => {
    ctx.fillStyle = 'rgba(0,0,0,0.05)';
    ctx.fillRect(0, 0, canvas.width, canvas.height);
    ctx.fillStyle = "#0f0";

    ctx.font = '${fontSize}px monospace';
    for (let i = 0; i < drops.length; i++) {
        const text = matrixChars.charAt(Math.floor(Math.random() * matrixChars.length));
        const x = 1 * fontSize;
        const y = drops[i] * fontSize;

        ctx.fillText(text, x, y);
        if (y > canvas.height && Math.random() > 0.975) {
            drops[i] = 0;
        }
        drops[i]++;
    }
}
setInterval(draw, 50);


document.querySelector('.hamburger').addEventListener('click', () => {
    document.querySelector('.nav-items').classList.toggle('show');
});

// Initialize all sliders
function initSliders() {
    const sliders = document.querySelectorAll('.slider-wrapper');

    sliders.forEach(wrapper => {
        const slider = wrapper.querySelector('.slider');
        const prevBtn = wrapper.querySelector('.prev');
        const nextBtn = wrapper.querySelector('.next');
        const images = slider.querySelectorAll('img');
        let currentIndex = 0;

        // Set image widths
        images.forEach(img => {
            img.style.width = `${wrapper.offsetWidth}px`;
        });

        // Navigation handlers
        prevBtn.addEventListener('click', () => {
            currentIndex = Math.max(currentIndex - 1, 0);
            updateSlider();
        });

        nextBtn.addEventListener('click', () => {
            currentIndex = Math.min(currentIndex + 1, images.length - 1);
            updateSlider();
        });

        function updateSlider() {
            const translateX = -currentIndex * wrapper.offsetWidth;
            slider.style.transform = `translateX(${translateX}px)`;

            // Disable buttons at ends
            prevBtn.disabled = currentIndex === 0;
            nextBtn.disabled = currentIndex === images.length - 1;
        }

        // Handle window resize
        window.addEventListener('resize', () => {
            images.forEach(img => {
                img.style.width = `${wrapper.offsetWidth}px`;
            });
            updateSlider();
        });

        updateSlider();
    });
}

// Call when page loads
window.addEventListener('load', initSliders);