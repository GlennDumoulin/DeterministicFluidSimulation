import json
import glob
import numpy as np

# Function to calculate trimmed mean
def trimmed_mean(data, trim_percent):
    n = len(data)
    trim_count = int(n * trim_percent)
    trimmed_data = sorted(data)[trim_count:n - trim_count]
    return np.mean(trimmed_data)

# Initialize lists to store averages from each file
cpu_averages = []
gpu_averages = []

# Load and process each JSON file
file_pattern = 'PerformanceData/*.json'  # Change this pattern to match your file path
files = glob.glob(file_pattern)

# Prepare output file
output_file = 'PerformanceResults.txt'

with open(output_file, 'w') as out:
    for file in files:
        with open(file, 'r') as f:
            data = json.load(f)
            
        # Extract CPU and GPU times and calculate combined times
        combined_times = [(step['CPUTimeMs'], step['GPUTimeMs']) for step in data['Steps']]

        # Sort by combined time
        combined_times.sort(key=lambda x: x[0] + x[1])

        # Trim 10% from each end based on combined time
        n = len(combined_times)
        trim_count = int(n * 0.1)
        trimmed_times = combined_times[trim_count:n - trim_count]

        # Separate CPU and GPU times after trimming
        cpu_times = [t[0] for t in trimmed_times]
        gpu_times = [t[1] for t in trimmed_times]

        # Calculate trimmed averages
        cpu_avg = np.mean(cpu_times)
        gpu_avg = np.mean(gpu_times)

        # Store averages for final processing
        cpu_averages.append(cpu_avg)
        gpu_averages.append(gpu_avg)
        
        # Print averages
        print(f"{file}:")
        print(f"  CPU Average Frame Time: {cpu_avg:.5f}ms")
        print(f"  GPU Average Frame Time: {gpu_avg:.5f}ms\n")
        
        out.write(f"{file}:\n")
        out.write(f"  CPU Average Frame Time: {cpu_avg:.5f}ms\n")
        out.write(f"  GPU Average Frame Time: {gpu_avg:.5f}ms\n\n")

    # Final trimming across all files
    final_cpu_avg = trimmed_mean(cpu_averages, 0.1)
    final_gpu_avg = trimmed_mean(gpu_averages, 0.1)

    # Print results
    print("\nFinal Averages:")
    print(f"  Final CPU Average Frame Time: {final_cpu_avg:.5f}ms")
    print(f"  Final GPU Average Frame Time: {final_gpu_avg:.5f}ms")

    out.write("\nFinal Averages:\n")
    out.write(f"  Final CPU Average Frame Time: {final_cpu_avg:.5f}ms\n")
    out.write(f"  Final GPU Average Frame Time: {final_gpu_avg:.5f}ms\n")
