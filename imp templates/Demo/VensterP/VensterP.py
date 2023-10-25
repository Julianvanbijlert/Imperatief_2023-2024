from tkinter import Frame


scherm = Frame()
scherm.master.title("Hallo")
scherm.configure(background="lightblue")
scherm.configure(width=200, height=100)
scherm.pack()

scherm.mainloop()