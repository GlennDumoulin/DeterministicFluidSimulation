import json
import glob
import numpy as np

# Function to calculate Euclidean distance
def euclidean_distance(v1, v2):
    return np.sqrt((v1['x'] - v2['x'])**2 + (v1['y'] - v2['y'])**2)

# Function to calculate color difference
def color_difference(c1, c2):
    return (abs(c1['r'] - c2['r']) + abs(c1['g'] - c2['g']) + abs(c1['b'] - c2['b']) + abs(c1['a'] - c2['a'])) / 4

# Function to calculate trimmed mean
def trimmed_mean(data, trim_percent):
    n = len(data)
    trim_count = int(n * trim_percent)
    trimmed_data = sorted(data)[trim_count:n - trim_count]
    return np.mean(trimmed_data)

# Load and process each JSON file
file_pattern = 'AccuracyData/*.json'  # Change this pattern to match your file path
files = glob.glob(file_pattern)

velocity_avg_list = []
color_avg_list = []

# Prepare output file
output_file = 'AccuracyResults.txt'

with open(output_file, 'w') as out:
    # Compare each pair of files
    for i in range(len(files) - 1):
        for j in range(i + 1, len(files)):
            with open(files[i], 'r') as f1, open(files[j], 'r') as f2:
                data1 = json.load(f1)
                data2 = json.load(f2)

            # Calculate velocity differences
            velocities1 = data1['Velocities']
            velocities2 = data2['Velocities']
            velocity_diffs = [euclidean_distance(v1, v2) for v1, v2 in zip(velocities1, velocities2)]

            # Calculate average
            avg_velocity_diff = trimmed_mean(velocity_diffs, 0.1)
            velocity_avg_list.append(avg_velocity_diff)

            # Calculate color differences
            colors1 = data1['Colors']
            colors2 = data2['Colors']
            color_diffs = [color_difference(c1, c2) for c1, c2 in zip(colors1, colors2)]

            # Calculate average
            avg_color_diff = trimmed_mean(color_diffs, 0.1)
            color_avg_list.append(avg_color_diff)

            print(f"Comparison between {files[i]} and {files[j]}:")
            print(f"  Average Velocity Difference: {avg_velocity_diff:.5f}")
            print(f"  Average Color Difference: {avg_color_diff:.5f}\n")
            
            out.write(f"Comparison between {files[i]} and {files[j]}:\n")
            out.write(f"  Average Velocity Difference: {avg_velocity_diff:.5f}\n")
            out.write(f"  Average Color Difference: {avg_color_diff:.5f}\n\n")

    # Calculate and print overall averages
    final_velocity_avg = trimmed_mean(velocity_avg_list, 0.1)
    final_color_avg = trimmed_mean(color_avg_list, 0.1)
    print("\nFinal Averages:")
    print(f"  Overall Average Velocity Difference: {final_velocity_avg:.5f}")
    print(f"  Overall Average Color Difference: {final_color_avg:.5f}")

    out.write("\nFinal Averages:\n")
    out.write(f"  Overall Average Velocity Difference: {final_velocity_avg:.5f}\n")
    out.write(f"  Overall Average Color Difference: {final_color_avg:.5f}\n")
