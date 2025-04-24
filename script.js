document.getElementById('current-year').textContent = new Date().getFullYear();
function toggleVideo(videoId, linkElement) {
    // Hide all other videos
    const allVideos = document.querySelectorAll('.video-container');
    allVideos.forEach(video => {
        if (video.id !== videoId) {
            video.style.display = 'none';
        }
    });

    // Reset all "View Preview" links to their default text
    const allLinks = document.querySelectorAll('a[onclick]');
    allLinks.forEach(link => {
        if (link.textContent === 'Hide Preview') {
            link.textContent = 'View Preview';
        }
    });

    // Toggle the selected video
    const videoContainer = document.getElementById(videoId);
    if (videoContainer.style.display === 'none' || videoContainer.style.display === '') {
        videoContainer.style.display = 'block';
        linkElement.textContent = 'Hide Preview';
    } else {
        videoContainer.style.display = 'none';
        linkElement.textContent = 'View Preview';
    }

    // Prevent the page from jumping to the top
    return false;
}