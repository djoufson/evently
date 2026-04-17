export async function streamDescription(title, tags, textareaId, buttonId) {
    const textarea = document.getElementById(textareaId);
    const button = document.getElementById(buttonId);
    if (!textarea || !button) return;

    button.disabled = true;
    textarea.value = '';
    textarea.dispatchEvent(new Event('input', { bubbles: true }));

    try {
        const response = await fetch('/api/events/generate-description', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, tags }),
        });

        if (!response.ok) {
            textarea.value = 'Failed to generate description. Please try again.';
            textarea.dispatchEvent(new Event('input', { bubbles: true }));
            return;
        }

        const reader = response.body.getReader();
        const decoder = new TextDecoder();

        while (true) {
            const { done, value } = await reader.read();
            if (done) break;
            textarea.value += decoder.decode(value, { stream: true });
        }

        textarea.dispatchEvent(new Event('change', { bubbles: true }));
    } finally {
        button.disabled = false;
    }
}
