from tkinter import Frame, Menu
from BitmapControl import BitmapControl

class BitmapEditorP(Frame):
    def __init__(self):
        super().__init__()
        self.master.title("BitmapEditorP")
        self.master.geometry("500x300")
        self.pack(fill="both", expand=True)

        viewer = BitmapControl(self)
        viewer.pack(fill="both", expand=True)

        menubar = Menu(self)
        filemenu = Menu(menubar, tearoff=0)
        filemenu.add_command(label="Exit", command=self.master.quit)
        menubar.add_cascade(label="File", menu=filemenu)

        movemenu = Menu(menubar, tearoff=0)
        movemenu.add_command(label="Left", command=viewer.Left)
        movemenu.add_command(label="Right", command=viewer.Right)
        movemenu.add_command(label="Up", command=viewer.Up)
        movemenu.add_command(label="Down", command=viewer.Down)
        menubar.add_cascade(label="Move", menu=movemenu)

        editmenu = Menu(menubar, tearoff=0)
        editmenu.add_command(label="Clear", command=viewer.Clear)
        editmenu.add_separator()
        editmenu.add_command(label="Invert", command=viewer.Invert)
        editmenu.add_command(label="Bold", command=viewer.Bold)
        editmenu.add_command(label="Outline", command=viewer.Outline)
        menubar.add_cascade(label="Edit", menu=editmenu)

        lifemenu = Menu(menubar, tearoff=0)
        lifemenu.add_command(label="Step", command=viewer.Life)
        lifemenu.add_command(label="Start", command=viewer.Starten)
        lifemenu.add_command(label="Stop", command=viewer.Stoppen)
        menubar.add_cascade(label="Life", menu=lifemenu)

        self.master.configure(menu=menubar)