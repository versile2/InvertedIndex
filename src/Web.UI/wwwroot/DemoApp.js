window.clipboardCopy = {
    copyText: async function (text) {
        try {
            await navigator.clipboard.writeText(text);
            return { success: true, message: "Copied to clipboard!" };
        } catch (error) {
            return { success: false, message: error.message || "Failed to copy to clipboard" };
        }
    }
};
