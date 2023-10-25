import sys

def bewerk(patroon, filenaam):
    try:
        if filenaam=="":
            reader = sys.stdin
        else:
            reader = open(filenaam, "r")

        nr=1
        for regel in reader:
            if regel.find(patroon)>=0:
                print(f"{filenaam}, line {nr}: {regel.strip()}")
            nr+=1
        reader.close()
    except Exception as exc:
        print(f"{filenaam}: {str(exc)}")

n = len(sys.argv)
if n==1:
    print("Usage: Grep pattern [files]")
elif n==2:
    bewerk(sys.argv[1], "")
else:
    for arg in sys.argv[2:]:
        bewerk(sys.argv[1], arg)
